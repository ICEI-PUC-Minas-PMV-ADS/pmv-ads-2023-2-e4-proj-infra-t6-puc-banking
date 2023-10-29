import React from 'react';
// Components
import { GrFormNext, GrFormPrevious } from 'react-icons/gr';
import RegisterUserForm from '../Components/RegisterUserForm';
import RegisterCardForm from '../Components/RegisterCardForm';
import RegisterThanks from '../Components/RegisterThanksForm';

//Hoks
import { useForm } from "../hooks/useForm";


export default function RegisterPage() {
    const formComponents = [<RegisterUserForm />, <RegisterCardForm />, <RegisterThanks />]
    const {currentStep, currentComponent} = useForm(formComponents)

    return (
        <div className='app'>
            <div className='header'>
                <h2>Vamos criar sua conta</h2>
                <p>Estamos a poucos passos de ter você conosco</p>
            </div>
            <div className='form-container'>
                <p>etapas</p>
                <form>
                    <div className='inputs-container'>{currentComponent}</div>
                    <div className='actions'>
                        <button type='button'>
                            <GrFormPrevious />
                            <span>Voltar</span>
                        </button>
                        <button type='submit'>
                            <span>Avançar</span>
                            <GrFormNext />
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
}