import { useState } from "react";

export function useForm(steps) {
    const [currentStep, setCurrentstep] = useState(0)

    function changeStep(i, e) {
       if (e) e.preventDefault();

        if (i < 0 || i >= steps.length) return

        setCurrentstep(i)

        
    }

    return {
        currentStep,
        currentComponent: steps[currentStep],
        changeStep,
        isLastStep: currentStep + 1 === steps.length ? true : false,
    };
}