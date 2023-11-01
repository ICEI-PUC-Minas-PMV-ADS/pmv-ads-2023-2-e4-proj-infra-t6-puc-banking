import React from "react";

const RegisterCardForm = () => {
    return (
        <div>
            <div>
            <div className="form-control">
                <label htmlFor="senha">Senha do Cartão:</label>
                <input type="text" name="password" id="senha" placeholder="Digite a senha do cartão" required></input>
            </div>
            <div className="form-control">
                <label htmlFor="Confirm-Senha">Confirme a senha do Cartão:</label>
                <input type="text" name="confirmSenha" id="confirmSenha" placeholder="Digite a senha do cartão" required></input>
            </div>
            <div className="form-control">
                <label htmlFor="sennha-app">Senha do Aplicativo:</label>
                <input type="text" name="senha-app" id="senha-app" placeholder="Digite a senha do cartão" required></input>
            </div>
        </div>
        </div>
    )
}
export default RegisterCardForm