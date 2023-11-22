import React, { createContext, useState } from "react";
import { useInitialRender } from '../hooks/useInitialRender';
import EventProvider from '../utils/EventProvider';
import * as UserService from '../services/UserService';

const UserContext = createContext({});

export function UserProvider({ children }) {

    const [userData, setUserdata] = useState(undefined);
    const [accountData, setAccountdata] = useState(undefined);
    const [cardData, setCardData] = useState(undefined);

    useInitialRender(() => {
        EventProvider.subscribe('AuthenticationChanged', (data) => {

            if (data.isAuthenticated) {

                console.log('Atualizando usuário');

                Promise.all([UserService.getUserInfo(), UserService.getAccountInfo(), UserService.getCardInfo()])
                    .then(([userInfo, accountInfo, cardInfo]) => {
                        setUserdata(userInfo.data);
                        setAccountdata(accountInfo.data);
                        setCardData(cardInfo.data);
                        EventProvider.publish('UserUpdated', undefined);
                });
            }
        })
    });

    return (
        <UserContext.Provider value={{userData, accountData, cardData}}>
            {children}
        </UserContext.Provider>
    );
}

export default UserContext;
