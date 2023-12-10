import React, { useContext } from "react";
import { View, Text, StyleSheet, FlatList } from 'react-native';
import { MaterialCommunityIcons } from '@expo/vector-icons';
import UserContext from '../contexts/UserContext';

export default function BillPage() {

    const { transactions } = useContext(UserContext);

    return (
        <View style={{height: '100%'}}>
            <Text style={styles.title}>Histórico de utilização</Text>
            <View style={styles.container}>
                <FlatList data={transactions} renderItem={renderItem}></FlatList>
            </View>
        </View>
    );
}

function renderItem({item}) {

    return (
        <View style={styles.transactionContainer}>
            <View style={styles.iconContainer}>
                <MaterialCommunityIcons name="cash-multiple" size={24} color={'#3F4145'}></MaterialCommunityIcons>
            </View>
            <View style={styles.infos}>
                <Text style={styles.name}>{item.name}</Text>
                <Text style={styles.time}>{item.createdOn}</Text>
            </View>
            <Text style={styles.value}>{item.value}</Text>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        width: '90%',
        backgroundColor: '#F5F4F4',
        marginLeft: '5%',
        marginTop: 20,
        borderRadius: 12,
        paddingHorizontal: 12
    },
    title: {
        fontSize: 18,
        fontWeight: 'bold',
        marginLeft: '5%',
        marginTop: 20
    },
    transactionContainer: {
        width: '100%',
        paddingVertical: 12,
        flex: 0,
        flexDirection: 'row'
    },
    iconContainer: {
        borderRadius: 48,
        backgroundColor: '#D9D9D9',
        width: 48,
        height: 48,
        flex: 0,
        alignItems: 'center',
        justifyContent: 'center'
    },
    infos: {
        marginLeft: 12,
        width: '60%'
    },
    name: {
        fontWeight: 'bold',
        fontSize: 16
    },
    value: {
        fontWeight: 'bold',
        fontSize: 16
    }
});