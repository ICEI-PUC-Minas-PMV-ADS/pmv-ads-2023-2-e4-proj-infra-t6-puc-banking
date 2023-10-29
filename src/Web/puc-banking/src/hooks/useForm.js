import { useState } from "react";

export function useForm(steps) {
    const [currentStep, setCurrentstep] = useState(0)


    return {
        currentStep,
        currentComponent: steps[currentStep],
    };
}