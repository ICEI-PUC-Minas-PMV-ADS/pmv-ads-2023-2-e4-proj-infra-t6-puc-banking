import React from "react"
import { View } from 'react-native';
import { Spinner } from 'native-base';

export default function LoadingPage() {
    return (
        <View style={{height: '100%', width: '100%', justifyContent: 'center'}}>
            <Spinner size='xl' color='#7076F4'/>
        </View>
    );
}