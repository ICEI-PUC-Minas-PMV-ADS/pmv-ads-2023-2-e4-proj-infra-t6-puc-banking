import axios from 'axios';

const API = axios.create({
 baseURL: process.env.REACT_APP_API_GATEWAY_HOST,
 headers: {
    'Access-Control-Allow-Origin' : '*',
    'Access-Control-Allow-Methods':'GET,PUT,POST,DELETE,PATCH,OPTIONS',
    'Access-Control-Allow-Headers':'Content-Type, Authorization, X-Requested-With'
}
});

export default API;
