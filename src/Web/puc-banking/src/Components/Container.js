import React from 'react';
import pucImg from '/Users/bruno.selas.oikos/Documents/projetos/pmv-ads-2023-2-e4-proj-infra-t6-puc-banking/src/Web/puc-banking/src/assets/PucImg.png';

export default function Container(props) {
    return (
        <div className='container'>
            <div className='container-login '>
                <div className='wrap-login'>
                    <form className='login-form'>
                        <span className='login-form-title'>Bem Vindo!</span>
                        <span className='login-form-login'>
                            <img src={pucImg} alt='Logo Puc' />
                        </span>

                        <div className='wrap-input'>
                            <input type='email' />
                            <span className='focus-input' data-placeholder='Email'></span>
                        </div>

                        <div className='wrap-input'>
                            <input type='password' />
                            <span className='focus-input' data-placeholder='Password'></span>
                        </div>

                        <div className='container-login-form-btn'>
                            <button className='login-form-btn'>Login</button>
                        </div>

                        <div className='text-center'>
                            <span className='text1'>Não possui conta?</span>
                            <a className='text2' href='#'>Criar Conta</a>
                        </div>

                    </form>
                </div>
            </div>
        </div>
    );
}