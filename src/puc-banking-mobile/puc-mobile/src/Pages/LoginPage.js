import React, { useContext } from "react";
import {
    Image,
    SafeAreaView,
    StyleSheet,
    Text,
    TouchableOpacity
} from "react-native";
import { Input, FormControl, WarningOutlineIcon, Pressable, Icon, Button, Flex } from 'native-base';
import { MaterialIcons } from "@expo/vector-icons";
import AuthContext from '../contexts/AuthContext';
import { Authenticate } from "../services/IdentityService";

const illustration = require('../../assets/login-illustration.webp');

export default function LoginPage({ navigation }) {

    const [showPass, setShowPass] = React.useState(false);
    const [email, setEmail] = React.useState(null);
    const [password, setPassword] = React.useState(null);
    const [isInvalid, setIsInvalid] = React.useState(false);
    const [errorMessage, setErrorMessage] = React.useState(null);
    const [waitingResponse, setWaitingResponse] = React.useState(false);
    const { authenticate } = useContext(AuthContext);

    function handlePasswordInput(input) {
        setIsInvalid(false);
        setPassword(input);
    }

    function handleEmailInput(input) {
        setIsInvalid(false);
        setEmail(input);
    }

    function handleCadastre() {
        navigation.navigate('Cadastre');
    }

    function handleLogin() {
        setWaitingResponse(true);

        Authenticate(email, password)
            .then(function(response) {
                if (response.isAuthenticated) {
                    authenticate();
                } else {
                    setErrorMessage(response.message);
                    setIsInvalid(true);
                }

                setWaitingResponse(false)
            })
            .catch(function(error) {
                console.error(error);
                setErrorMessage(error);
                setWaitingResponse(false)
            });
    }

    return (
        <SafeAreaView style={styles.mainContainer}>
            <Image style={styles.illustration} source={illustration} />
            <Text style={styles.title}>Login</Text>
            <FormControl isInvalid={isInvalid} style={styles.form}>
                <Input variant="underlined" style={styles.input} _focus={styles.inputFocus} placeholder="Email" mb={3} onChangeText={handleEmailInput} />
                <Input variant="underlined" style={styles.input} _focus={styles.inputFocus} placeholder="Password" mb={3} onChangeText={handlePasswordInput} type={showPass ? "text" : "password"} InputRightElement={
                    <Pressable onPress={function () { setShowPass(!showPass) }}>
                        <Icon as={<MaterialIcons name={showPass ? "visibility" : "visibility-off"} />} size={5} mr='2' color='muted.400' />
                    </Pressable>
                } />
                <FormControl.ErrorMessage leftIcon={<WarningOutlineIcon size='xs' />}>{errorMessage}</FormControl.ErrorMessage>
            </FormControl>
            <Button onPress={handleLogin} style={styles.button}>Login</Button>
            <Flex direction="row" alignItems='center' justifyContent='center' pr='3' pl='3' mt={5}>
                <Text>Não possui conta?</Text>
                <TouchableOpacity><Text onPress={handleCadastre} style={styles.registerLink}> Registre-se</Text></TouchableOpacity>
            </Flex>
        </SafeAreaView>
    )
}

const styles = StyleSheet.create({
    mainContainer: {
        height: '100%',
        width: '100%',
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'flex-start',
        alignItems: 'center'
    },
    illustration: {
        marginTop: 50,
        maxWidth: 300,
        height: 300
    },
    title: {
        textAlign: 'left',
        fontSize: 28,
        fontWeight: '500',
        color: '#333',
        width: '100%',
        marginLeft: 50
    },
    form: {
        width: '85%',
        marginTop: 20
    },
    input: {
        color: '#333'
    },
    inputFocus: {
        borderColor: '#7076F4',
        selectionColor: "#7076F4",
        background: "#fca5a5"
    },
    button: {
        marginTop: 20,
        backgroundColor: '#969BF7',
        width: '85%'
    },
    registerLink: {
        fontWeight: '700',
        color: '#7076F4',
    }
});