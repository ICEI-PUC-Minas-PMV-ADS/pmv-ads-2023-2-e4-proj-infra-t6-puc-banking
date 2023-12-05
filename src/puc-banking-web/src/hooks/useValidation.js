import { useState } from "react";

export function useValidation(validation) {

    const [isValid, setIsValid] = useState(true);
    const [message, setMessage] = useState(undefined);

    function validate(value) {
        setIsValid(true);
        setMessage(undefined);

        const result = validation(value);

        if (!result.isValid) {
            setIsValid(false);
            setMessage(result.message);
        }
    }

    return {
        isValid,
        message,
        validate
    }
}
