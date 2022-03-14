import axios from "axios";

const brasilapi = axios.create ({
    baseURL: 'https://localhost:7013'
})

export default brasilapi;