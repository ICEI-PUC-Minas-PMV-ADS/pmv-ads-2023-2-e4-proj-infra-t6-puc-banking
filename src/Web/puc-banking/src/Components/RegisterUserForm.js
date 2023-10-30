import React from "react";

const RegisterUserForm = () => {
    return (
        <div>
            <div className="form-control">
                <label htmlFor="name">Nome Completo</label>
                <input type="text" name="text" id="name" placeholder="Digite seu nome" required></input>
            </div>
        </div>
    )
}
export default RegisterUserForm