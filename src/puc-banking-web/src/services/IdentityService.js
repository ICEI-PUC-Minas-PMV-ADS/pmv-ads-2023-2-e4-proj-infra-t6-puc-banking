import API from './api';

export async function Authenticate(username, password) {

    var result = {};

    try {

        const response = await API.post(process.env.REACT_APP_AUTH_AUTHENTICATE, {
            email: username,
            password: password
        });

        API.defaults.headers.Authorization = `Bearer ${response.data.token}`;
        localStorage.setItem('@PUCBanking:username', username)
        localStorage.setItem('@PUCBanking:token', response.data.token);

        result.message = 'Usuário autenticado com sucesso.';
        result.isAuthenticated = true;
    } catch (err) {

        if (err.code === 'ERR_NETWORK') {
            result.message = "Erro ao se comunicar com o servidor. Tente novamente mais tarde.";
        } else {
            switch (err.response.status) {
                case 401:
                    result.message = "Usuário ou senha incorretos.";
                    break;
                default:
                    result.message = 'Erro não identificado. contate o administrador.';
                    break;
            }
        }

        result.isAuthenticated = false;
    }

    return result;
}

export async function Register(user) {

    var result = {};

    console.log(process.env.REACT_APP_AUTH_REGISTER);

    try {
        const response = await API.post(process.env.REACT_APP_AUTH_REGISTER, {
            firstName: user.name.split(' ')[0],
            lastName: user.name.split(' ')[1],
            email: user.email,
            password: user.password
        });

        result.message = response.data.message;
        result.userCreated = true;

    } catch (err) {

        if (err.code === 'ERR_NETWORK') {
            result.message = "Erro ao se comunicar com o servidor. Tente novamente mais tarde.";
        } else {
            switch (err.response.status) {
                case 400:
                    result.message = err.response.data.message ?? 'Um ou mais campos estão incorretos.';
                    break;
                default:
                    result.message = 'Erro não identificado. contate o administrador.';
                    break;
            }
        }

        result.userCreated = false;
    }

    return result;
}

export function Logout() {
    localStorage.removeItem('@PUCBanking:username');
    localStorage.removeItem('@PUCBanking:token');
}

export async function VerifyToken() {

    try {

        const username = localStorage.getItem('@PUCBanking:username');
        const token = localStorage.getItem('@PUCBanking:token');

        if (token === null ||
            username === null) {
            return false;
        }

        const response = await API.get(process.env.REACT_APP_AUTH_VERIFY, {
            params: {
                token: token,
                username: username
            }
        });

        const tokenIsValid = response.data.isValid;
        const tokenIsExpired = response.data.isExpired;

        if (tokenIsExpired ||
            tokenIsValid === false) {
            return false;
        }

        API.defaults.headers.Authorization = `Bearer ${token}`;

        return true;

    } catch(err) {
        return false;
    }
}
