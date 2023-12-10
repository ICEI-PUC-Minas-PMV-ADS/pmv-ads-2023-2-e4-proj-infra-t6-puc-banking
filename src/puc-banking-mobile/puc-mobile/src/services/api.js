import axios from 'axios';

const API_GATEWAY_HOST = 'https://localhost:44300/v1/gateway';

const API = axios.create({
 baseURL: API_GATEWAY_HOST,
 headers: {
    'Access-Control-Allow-Origin' : '*',
    'Access-Control-Allow-Methods':'GET,PUT,POST,DELETE,PATCH,OPTIONS',
    'Access-Control-Allow-Headers':'Content-Type, Authorization, X-Requested-With'
}
});

export default API;
