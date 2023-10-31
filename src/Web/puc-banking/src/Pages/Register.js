import React from 'react';
// Components
import { GrFormNext, GrFormPrevious } from 'react-icons/gr';
import { FiSend } from "react-icons/fi";
import RegisterUserForm from '../Components/RegisterUserForm';
import RegisterCardForm from '../Components/RegisterCardForm';
import RegisterThanks from '../Components/RegisterThanksForm';
import RegisterSteps from '../Components/RegisterSteps';
import '../RegisterPage.css'

//Hoks
import { useForm } from "../hooks/useForm";


export default function RegisterPage() {
    const formComponents = [<RegisterUserForm />, <RegisterCardForm />, <RegisterThanks />]
    const { currentStep, currentComponent, changeStep, isLastStep, isFirstSetp } = useForm(formComponents)

    return (
        <div className='app'>
            <div className='header'>
                <h2>Vamos criar sua conta</h2>
                <p>Estamos a poucos passos de ter você conosco</p>
            </div>
            <div className='form-container'>
                <RegisterSteps currentStep={currentStep} />
                <form onSubmit={(e) => changeStep(currentStep + 1, e)}>
                    <div className='inputs-container'>{currentComponent}</div>
                    <div className='actions'>
                        {!isFirstSetp && (
                            <button type='button' onClick={() => changeStep(currentStep - 1)}>
                                <GrFormPrevious />
                                <span>Voltar</span>
                            </button>
                        )}
                        {!isLastStep ? (
                            <button type='submit'>
                                <span>Avançar</span>
                                <GrFormNext />
                            </button>
                        ) : (
                            <button type='button'>
                                <span>Cadastrar</span>
                                <FiSend />
                            </button>
                        )}
                    </div>
                </form>
            </div>
        </div>
    );
}