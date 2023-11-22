import React, { useState } from "react";
import '../styles/LoginPage.css';
import PucLogoDark from '../assets/puc-logo-dark.png';
import { useAuth } from '../hooks/useAuth';

export default function LoginPage() {

    const [isLoading, setIsLoading] = useState(false);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const {authenticate} = useAuth();

    const handleLogin = (e) => {

        e.preventDefault();

        setIsLoading(true);

        authenticate(email, password)
            .then((value) => {
                if (value.isAuthenticated === false) {
                    alert(value.message);
                    setIsLoading(false);
                }
            });
    };

    return (
        <div className="container-login">
            <div className="wrap-login d-flex flex-column">
                <form className='login-form'>
                    <span className='login-form-title'>Bem Vindo!</span>
                    <img className="login-form-image" src={PucLogoDark} alt="Logo PUCMinas" />

                    <div className='wrap-input'>
                        <input className={email !== "" ? 'has-val input' : 'input'} type='email' value={email} onChange={e => setEmail(e.target.value)} />
                        <span className='focus-input' data-placeholder='Email'></span>
                    </div>

                    <div className='wrap-input'>
                        <input className={password !== "" ? 'has-val input' : 'input'} type='password' value={password} onChange={e => setPassword(e.target.value)} />
                        <span className='focus-input' data-placeholder='Password'></span>
                    </div>

                    <button disabled={isLoading} className='login-form-btn' onClick={handleLogin}>
                        {
                            isLoading ? (
                                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                            ) : (<span>Login</span>)
                        }
                    </button>

                    <div className='register-info-container'>
                        <span className='register-info-text'>Não possui conta?</span>
                        <a className='register-info-link' href='/register'>Criar Conta</a>
                    </div>
                </form>
            </div>
        </div>
    );
}
