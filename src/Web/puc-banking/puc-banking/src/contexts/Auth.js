import React, { createContext, useState } from "react";
import EventProvider from '../utils/EventProvider';
import * as IdentityService from '../services/IdentityService';

const AuthContext = createContext({});

export function AuthProvider({ children }) {

    const [isAuthenticated, setIsAuthenticated] = useState(false);

    const authenticate = async (username, password) => {

        var result = await IdentityService
            .Authenticate(username, password);

        EventProvider.publish('AuthenticationChanged', { isAuthenticated: true });
        setIsAuthenticated(result.isAuthenticated);

        return result;
    }

    async function verifyToken() {

        var result = await IdentityService
            .VerifyToken();

        if (result === false) {
            setIsAuthenticated(false);
        } else {
            EventProvider.publish('AuthenticationChanged', { isAuthenticated: true });
            setIsAuthenticated(true);
        }
    }

    function logout() {
        IdentityService.Logout();
        EventProvider.publish('AuthenticationChanged', { isAuthenticated: false });
        setIsAuthenticated(false);
    }

    async function register(user) {

        var result = await IdentityService
            .Register(user);

        return result;
    }

    return (
        <AuthContext.Provider value={{isAuthenticated, verifyToken, authenticate, logout, register }}>
            {children}
        </AuthContext.Provider>
    );
}


export default AuthContext;
