import React, { useState } from 'react';
import { BrowserRouter, Route, Routes as RouteCollection, Navigate } from "react-router-dom";
import { useInitialRender } from '../hooks/useInitialRender';
import { useAuth } from '../hooks/useAuth';
import { useUser } from '../hooks/useUser';
import LoadingPage from '../pages/LoadingPage';
import WelcomePage from '../pages/WelcomePage';
import RegisterPage from '../pages/RegisterPage';
import LoginPage from '../pages/LoginPage';
import Shell from '../components/Shell';
import EventProvider from '../utils/EventProvider';

export default function Routes() {

    const [loading, setLoading] = useState(true);
    const [userLoaded, setUserLoaded] = useState(false);
    const authContext = useAuth();

    useInitialRender(() => {

        EventProvider.subscribe('UserUpdated', (data) => {
            setUserLoaded(true);
        });

        authContext.verifyToken()
            .then((result) => {
                setLoading(false);
            });
    });

    if (loading)
        return <Loading></Loading>;

    if (authContext.isAuthenticated && !userLoaded)
        return <Loading></Loading>;

    if (authContext.isAuthenticated) {
        return <AuthenticatedRoutes/>;
    } else {
        return <UnauthenticatedRoutes/>;
    }
}

function Loading() {
    return (
        <BrowserRouter>
            <RouteCollection>
                <Route path='*' Component={LoadingPage}/>
            </RouteCollection>
        </BrowserRouter>
    );
}

function UnauthenticatedRoutes() {
    return (
        <BrowserRouter>
            <RouteCollection>
                <Route path='/' Component={WelcomePage}/>
                <Route path='login' Component={LoginPage}/>
                <Route path='register' Component={RegisterPage}/>
            </RouteCollection>
        </BrowserRouter>
    );
}

function AuthenticatedRoutes() {
    return (
        <BrowserRouter>
            <RouteCollection>
                <Route path='/' Component={Shell}/>
                <Route path='*' element={<Navigate to='/'></Navigate>}/>
            </RouteCollection>
        </BrowserRouter>
    );
}

