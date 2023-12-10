import API from './api';

const AUTH_AUTHENTICATE= '/identity/authenticate';
const AUTH_REGISTER='/identity/register';
const AUTH_AUTHENTICATED='/identity/authenticated';
const AUTH_VERIFY='/identity/verify';

export async function Authenticate(username, password) {

    var result = {};

    await API.post(AUTH_AUTHENTICATE, {
        email: username,
        password: password
    })
        .then(async function (response) {
            API.defaults.headers.Authorization = `Bearer ${response.data.token}`;
            await AsyncStorage.setItem('@PUCBanking:username', username)
            await AsyncStorage.setItem('@PUCBanking:token', response.data.token);

            result.message = 'Usuário autenticado com sucesso.';
            result.isAuthenticated = true;
        })
        .catch(function (error) {

            result.message = error.message; 

            result.isAuthenticated = false;
        })

    return result;
}

export async function Register(user) {

    var result = {};

    try {
        const response = await API.post(AUTH_REGISTER, {
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
    AsyncStorage.removeItem('@PUCBanking:username');
    AsyncStorage.removeItem('@PUCBanking:token');
}

export async function VerifyToken() {

    try {

        const username = await AsyncStorage.getItem('@PUCBanking:username');
        const token = await AsyncStorage.getItem('@PUCBanking:token');

        if (token === null ||
            username === null) {
            return false;
        }

        const response = await API.get(AUTH_VERIFY, {
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

    } catch (err) {
        return false;
    }
}
