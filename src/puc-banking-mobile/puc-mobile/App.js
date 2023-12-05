import React from "react";
import { NativeBaseProvider } from "native-base";
import { SafeAreaProvider } from "react-native-safe-area-context";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import HomePage from "./src/Pages/HomePage";
import LoginPage from "./src/Pages/LoginPage";
import CadastrePage from "./src/Pages/CadastrePage";

const Stack = createNativeStackNavigator();

export default function App() {
  const [isLoading, setIsLoading] = React.useState(false);
  const [isSignedIn, setIsSignedIn] = React.useState(false);

  return (
    <SafeAreaProvider>
      <NativeBaseProvider>
        <NavigationContainer>
          <Stack.Navigator screenOptions={{ headerShown: false }}>
            {isSignedIn ? (
              <>
                <Stack.Screen name="Home" component={HomePage} />
              </>
            ) : (
              <>
                <Stack.Screen name="Login" component={LoginPage} />
                <Stack.Screen name="Cadastre" component={CadastrePage} />
              </>
            )}
          </Stack.Navigator>
        </NavigationContainer>
      </NativeBaseProvider>
    </SafeAreaProvider>
  );
}
