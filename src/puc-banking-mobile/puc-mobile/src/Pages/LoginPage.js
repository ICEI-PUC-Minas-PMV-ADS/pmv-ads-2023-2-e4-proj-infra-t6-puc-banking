import { View, TextInput, Image, TouchableOpacity, Text, SafeAreaView } from "react-native";
import React from "react";


export default function LoginPage() {
  return (
    <SafeAreaView style={{ flex: 1, justifyContent: 'center', }}>
      <View style={{ paddingHorizontal: 25, }}>
        <View style={{ alignItems: 'center' }}>
          <Image source={require('../../assets/card-foto.webp')} style={{ height: 300, width: 300, }} />
        </View>
        <Text style={{ fontFamily: 'Roboto', fontSize: 28, fontWeight: 500, color: '#333', marginBottom: 30, }} >Login</Text>
        <View style={{ flexDirection: 'row', borderBottomColor: '#ccc', borderBottomWidth: 1, paddingBottom: 8, marginBottom: 25, }}>
          <TextInput placeholder="E-mail" style={{ flex: 1, paddingVertical: 0, }} keyboardType="email-adress"></TextInput>
        </View>
        <View style={{ flexDirection: 'row', borderBottomColor: '#ccc', borderBottomWidth: 1, paddingBottom: 8, marginBottom: 25, }}>
          <TextInput placeholder="Senha" style={{ flex: 1, paddingVertical: 0, }} secureTextEntry={true}></TextInput>
          <TouchableOpacity><Text style={{ color: '#AD40AF', fontWeight: '700', }}>Esqueceu a Senha?</Text></TouchableOpacity>
        </View>
        <TouchableOpacity style={{ backgroundColor: '#AD40AF', padding: 20, borderRadius: 10, marginBottom: 30, }}><Text style={{ textAlign: 'center', fontWeight: '700', fontSize: 16, color: '#fff', }}>Login</Text></TouchableOpacity>
        <View style={{ flexDirection: 'row', justifyContent: 'center', marginBottom: 30, }}>
          <Text>Não possui conta?</Text>
          <TouchableOpacity><Text style={{ color: '#AD40AF', fontWeight: '700', }}> Registre-se</Text></TouchableOpacity>
        </View>
      </View>
    </SafeAreaView>

  )
} 
