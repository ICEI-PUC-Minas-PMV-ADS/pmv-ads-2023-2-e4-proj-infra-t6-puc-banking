import React from "react";
import { View } from "react-native";
import { Header } from "../Components/Header";
import { Tabbar } from "../Components/Tabbar";

export default function MainPage({navigation}) {

    return (
        <View style={{ height: "100%" }}>
            <Header></Header>
            <Tabbar navigation={navigation}></Tabbar>
        </View>
    )
}