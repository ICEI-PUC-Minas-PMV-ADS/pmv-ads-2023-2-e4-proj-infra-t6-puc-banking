import React, { createContext, useState } from "react";
import { useInitialRender } from '../hooks/useInitialRender';
import EventProvider from '../utils/EventProvider';
import * as UserService from '../services/UserService';

const UserContext = createContext({});

export function UserProvider({ children }) {

    const [userData, setUserdata] = useState(undefined);
    const [accountData, setAccountdata] = useState(undefined);
    const [cardData, setCardData] = useState(undefined);
    const [transactions, setTransactions] = useState(undefined);
    const [interval, setInterval] = useState(null);

    useInitialRender(() => {
        EventProvider.subscribe('AuthenticationChanged', (data) => {

            if (data.isAuthenticated) {
                console.log('Atualizando usuário');

                Promise.all([UserService.getUserInfo(), UserService.getAccountInfo(), UserService.getCardInfo(), UserService.getTransactions()])
                    .then(([userInfo, accountInfo, cardInfo, transactions]) => {
                        setUserdata(userInfo.data);
                        setAccountdata(accountInfo.data);
                        setCardData(cardInfo.data);
                        setTransactions(transactions.data.transactions);
                        EventProvider.publish('UserUpdated', undefined);
                });

                const interval = setInterval(() => {
                    Promise.all([UserService.getUserInfo(), UserService.getAccountInfo(), UserService.getCardInfo(), UserService.getTransactions()])
                    .then(([userInfo, accountInfo, cardInfo, transactions]) => {
                        setUserdata(userInfo.data);
                        setAccountdata(accountInfo.data);
                        setCardData(cardInfo.data);
                        setTransactions(transactions.data.transactions);
                        EventProvider.publish('UserUpdated', undefined);
                });
                }, 2 * 60 * 1000); // 2 minutos em milissegundos

                setInterval(interval);

            } else {
                clearInterval(interval);
                setInterval(null);
            }
        })
    });

    return (
        <UserContext.Provider value={{userData, accountData, cardData, transactions}}>
            {children}
        </UserContext.Provider>
    );
}

export default UserContext;
