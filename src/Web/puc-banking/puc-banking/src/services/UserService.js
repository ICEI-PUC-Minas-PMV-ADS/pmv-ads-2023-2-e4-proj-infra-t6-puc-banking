import API from './api';

export async function getUserInfo() {

    var result = {};

    try {
        const response = await API.get(process.env.REACT_APP_USERS_AUTHENTICATED);

        result.message = response.data.message;
        result.data = response.data;
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
    }

    return result;
}

export async function getAccountInfo() {

    var result = {};

    try {
        const response = await API.get(process.env.REACT_APP_ACCOUNTS_AUTHENTICATED);

        result.message = response.data.message;
        result.data = response.data;
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
    }

    return result;
}

export async function getCardInfo() {

    var result = {};

    try {
        const response = await API.get(process.env.REACT_APP_CARDS_AUTHENTICATED);

        result.message = response.data.message;
        result.data = response.data;
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
    }

    return result;
}
