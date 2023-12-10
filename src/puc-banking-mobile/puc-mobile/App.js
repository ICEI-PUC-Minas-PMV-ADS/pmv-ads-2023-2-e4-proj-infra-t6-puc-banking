import React from "react";
import { NativeBaseProvider } from 'native-base';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import MainPage from "./src/pages/MainPage";
import LoginPage from "./src/pages/LoginPage";
import CadastrePage from "./src/pages/CadastrePage";
import LoadingPage from './src/pages/LoadingPage';
import AuthContext from './src/contexts/AuthContext';
import UserContext from './src/contexts/UserContext';
import { Authenticate, Register, Logout, VerifyToken } from "./src/services/IdentityService";
import * as UserService from './src/services/UserService';

const Stack = createNativeStackNavigator();

export default function App() {

  const [isLoading, setIsLoading] = React.useState(true);
  const [isSignedIn, setIsSignedIn] = React.useState(false);
  const [userData, setUserData] = React.useState(null);
  const [cardData, setCardData] = React.useState(null);
  const [transactions, setTransactions] = React.useState(null);

  React.useEffect(function () {
    VerifyToken()
      .then(async function (response) {
        if (response) {
          setIsSignedIn(true);
          authenticate();
        } else {
          setIsSignedIn(false);
          setIsLoading(false);
        }
      });
  }, []);

  function authenticate() {
    setIsLoading(true);

    Promise.all([UserService.getUserInfo(), UserService.getAccountInfo(), UserService.getCardInfo(), UserService.getTransactions()])
      .then(([userInfo, accountInfo, cardInfo, transactions]) => {
        setUserdata(userInfo.data);
        setAccountdata(accountInfo.data);
        setCardData(cardInfo.data);
        setTransactions(transactions.data.transactions);
        EventProvider.publish('UserUpdated', undefined);
      });
  }

  if (isLoading)
    return (
      <NativeBaseProvider>
        <LoadingPage></LoadingPage>
      </NativeBaseProvider>
    );


  return (
    <NativeBaseProvider>
      <AuthContext.Provider value={{ authenticate }}>
        <UserContext.Provider value={{ userData, cardData, transactions}}>
          <NavigationContainer>
            <Stack.Navigator screenOptions={{ headerShown: false }}>
              {isSignedIn ? (
                <>
                  <Stack.Screen name="Main" component={MainPage} />
                </>
              ) : (
                <>
                  <Stack.Screen name="Login" component={LoginPage} />
                  <Stack.Screen name="Cadastre" component={CadastrePage} />
                </>
              )}
            </Stack.Navigator>
          </NavigationContainer>
        </UserContext.Provider>
      </AuthContext.Provider>
    </NativeBaseProvider>
  );
}
