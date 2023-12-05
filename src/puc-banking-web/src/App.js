import React from 'react';
import './styles/App.css';
import { AuthProvider } from './contexts/Auth';
import { UserProvider } from './contexts/User';
import Routes from './routes/routes';

export default function App() {
    return (
        <div className='App'>
            <AuthProvider>
                <UserProvider>
                    <Routes></Routes>
                </UserProvider>
            </AuthProvider>
        </div>
    );
}
