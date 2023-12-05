import React, { useState } from "react";
import Container from "../components/Container";
import RegisterSteps from "../components/RegisterSteps";
import { useForm } from "../hooks/useForm";
import { GrFormNext, GrFormPrevious } from 'react-icons/gr';
import { FiSend } from "react-icons/fi";
import RegisterUserForm from "../components/RegisterUserForm";
import RegisterAuthForm from "../components/RegisterAuthForm";
import RegisterThanksForm from "../components/RegisterThanksForm";
import { useAuth } from '../hooks/useAuth';
import { useNavigate } from "react-router-dom";
import '../styles/RegisterPage.css';

export default function RegisterPage() {

    const [email, setEmail] = useState();
    const [password, setPassword] = useState();
    const [name, setName] = useState();
    const [cpf, setCpf] = useState();
    const {register} = useAuth();
    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

    const formComponents = [<RegisterUserForm setName={setName} setCpf={setCpf}/>, <RegisterAuthForm setEmail={setEmail} setPassword={setPassword}/>, <RegisterThanksForm/>];
    const { currentStep, currentComponent, changeStep, isLastStep, isFirstSetp } = useForm(formComponents);


    function handleRegister(e) {

        e.preventDefault();

        setIsLoading(true);

        register({
            name: name,
            email: email,
            password: password
        })
        .then((result) => {
            if (!result.userCreated) {
                alert(result.message);
            } else {
                navigate('/login');
            }
            setIsLoading(false);
        });

    }

    return (
        <Container className='register-container column justify-center'>
            <Container className='register-message column'>
                <h2>Vamos criar sua conta</h2>
                <p>Estamos a poucos passos de ter você conosco</p>
            </Container>

            <Container className='form-container column'>
                <Container className='mid-container column'>
                    <RegisterSteps currentStep={currentStep}></RegisterSteps>
                    <form onSubmit={(e) => { changeStep(currentStep + 1, e); }}>
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
                            <button type='button' onClick={(e) => { handleRegister(e) }} disabled={isLoading}>
                                <span>Cadastrar</span>
                                {
                                isLoading ? (
                                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                ) : (<FiSend />)
                                }
                            </button>
                        )}
                    </div>
                </form>
                </Container>
            </Container>
        </Container>
    );
}
