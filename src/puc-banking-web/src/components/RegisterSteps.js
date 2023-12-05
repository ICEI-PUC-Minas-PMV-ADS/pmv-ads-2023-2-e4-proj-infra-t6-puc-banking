import React from "react";
import { AiOutlineUser, AiOutlineStar } from "react-icons/ai";
import { FiSend } from "react-icons/fi";
import Container from "./Container";
import '../styles/RegisterSteps.css';

export default function RegisterSteps({ currentStep }) {
    return (
        <Container className='steps-container justify-space-between align-start'>
            <Container className={`step-container column ${currentStep >= 0 ? "active" : "desactive"}`}>
                <AiOutlineUser />
                <p>Indentificação</p>
            </Container>

            <Container className={`step-container column ${currentStep >= 1 ? "active" : "desactive"}`}>
                <AiOutlineStar />
                <p>Autenticação</p>
            </Container>

            <Container className={`step-container column ${currentStep >= 2 ? "active" : "desactive"}`}>
                <FiSend />
                <p>Envio</p>
            </Container>
        </Container>
    );
}
