import React from "react";
import { View, StyleSheet, Text, StatusBar, TouchableOpacity } from 'react-native';
import { Avatar } from "native-base";
import { MaterialCommunityIcons } from '@expo/vector-icons';

const statusBarHeight = StatusBar.currentHeight ? StatusBar.currentHeight + 22 : 64;

export function Header() {

    return (
        <View style={styles.container}>
            <View style={styles.content}>
                <Avatar bg="rgba(255,255,255,.95)">
                    <MaterialCommunityIcons name="account" size={25} color={'#B8BCFC'}></MaterialCommunityIcons>
                </Avatar>
                <Text style={styles.username}>Raul Oliveira</Text>
            </View>
            <TouchableOpacity>
                <MaterialCommunityIcons name="logout-variant" size={25} color={'#FFFFFF'}></MaterialCommunityIcons>
            </TouchableOpacity>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        backgroundColor: '#7076F4',
        flexDirection: 'row',
        paddingTop: statusBarHeight,
        paddingBottom: 10,
        paddingLeft: 12,
        paddingRight: 12,
        flex: 0,
        alignItems: 'center',
        flexDirection: 'row',
        justifyContent: 'flex-start',
    },
    content: {
        flex: 1,
        alignItems: 'center',
        flexDirection: 'row',
        justifyContent: 'flex-start',
    },

    username: {
        fontSize: 18,
        color: '#FFFFFF',
        fontWeight: 'regular',
        marginLeft: 18,
    },
})