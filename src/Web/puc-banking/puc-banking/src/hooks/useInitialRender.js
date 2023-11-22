import { useState } from "react";

export function useInitialRender(action) {

    const [isFirstRender, setIsFirstRender] = useState(true);

    if (isFirstRender) {
        action();
        setIsFirstRender(false);
    }
}
