import React from "react";
import {
    Image,
    SafeAreaView,
    StyleSheet,
    Text,
    TouchableOpacity
} from "react-native";
import { Input, FormControl, WarningOutlineIcon, Pressable, Icon, Button, Flex } from 'native-base';
import { MaterialIcons } from "@expo/vector-icons";

const illustration = require('../../assets/register-illustration.webp');

export default function CadastrePage({ navigation }) {

    const [showPass, setShowPass] = React.useState(false);
    const [name, setName] = React.useState(null);
    const [email, setEmail] = React.useState(null);
    const [password, setPassword] = React.useState(null);
    const [isInvalid, setIsInvalid] = React.useState(false);
    const [errorMessage, setErrorMessage] = React.useState(null);
    const [waitingResponse, setWaitingResponse] = React.useState(false);

    function handleNameInput(input) {
        setName(input);
    }

    function handleEmailInput(input) {
        setIsInvalid(false);
        setEmail(input);
    }

    function handlePasswordInput(input) {
        setIsInvalid(false);
        setPassword(input);
    }

    function handleRePasswordInput(input) {
        setIsInvalid(false);

        if (input !== password) {
            setIsInvalid(true);
            setErrorMessage('As senhas não são iguais.');
        }
    }

    function handleGoToLogin() {
        navigation.navigate('Login');
    }

    return (
        <SafeAreaView style={styles.mainContainer}>
            <Image style={styles.illustration} source={illustration} />
            <Text style={styles.title}>Vamos criar sua conta</Text>
            <FormControl isInvalid={isInvalid} style={styles.form}>
                <Input variant="underlined" style={styles.input} _focus={styles.inputFocus} placeholder="Nome Completo" mb={3} onChangeText={handleNameInput} />
                <Input variant="underlined" style={styles.input} _focus={styles.inputFocus} placeholder="Email" mb={3} onChangeText={handleEmailInput} />
                <Input variant="underlined" style={styles.input} _focus={styles.inputFocus} placeholder="Password" mb={3} onChangeText={handlePasswordInput} type={showPass ? "text" : "password"} InputRightElement={
                    <Pressable onPress={function () { setShowPass(!showPass) }}>
                        <Icon as={<MaterialIcons name={showPass ? "visibility" : "visibility-off"} />} size={5} mr='2' color='muted.400' />
                    </Pressable>
                } />
                <Input variant="underlined" style={styles.input} _focus={styles.inputFocus} placeholder="Re-Password" mb={3} onChangeText={handleRePasswordInput} type={showPass ? "text" : "password"} InputRightElement={
                    <Pressable onPress={function () { setShowPass(!showPass) }}>
                        <Icon as={<MaterialIcons name={showPass ? "visibility" : "visibility-off"} />} size={5} mr='2' color='muted.400' />
                    </Pressable>
                } />
                <FormControl.ErrorMessage leftIcon={<WarningOutlineIcon size='xs' />}>{errorMessage}</FormControl.ErrorMessage>
            </FormControl>
            <Button style={styles.button}>Criar conta</Button>
            <Flex direction="row" alignItems='center' justifyContent='center' pr='3' pl='3' mt={5}>
                <Text>Já possui conta?</Text>
                <TouchableOpacity><Text onPress={handleGoToLogin} style={styles.loginLink}> Login</Text></TouchableOpacity>
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
    loginLink: {
        fontWeight: '700',
        color: '#7076F4',
    }
});