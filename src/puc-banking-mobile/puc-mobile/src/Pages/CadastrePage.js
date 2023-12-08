import { View, TextInput, Image, TouchableOpacity, Text, SafeAreaView } from "react-native";
import React from "react";

export default function CadastrePage() {
  return (
    <SafeAreaView style={{ flex: 1, justifyContent: 'center', }}>
      <View style={{ paddingHorizontal: 25, }}>

        <View style={{ alignItems: 'center' }}>
          <Image source={require('../../assets/register-foto.webp')} style={{ height: 300, width: 300, }} />
        </View>

        <Text style={{ fontFamily: 'Roboto', fontSize: 28, fontWeight: 500, color: '#333', marginBottom: 30, }} >Vamos criar sua conta</Text>

        <View style={{ flexDirection: 'row', borderBottomColor: '#ccc', borderBottomWidth: 1, paddingBottom: 8, marginBottom: 25, }}>
          <TextInput placeholder="E-mail" style={{ flex: 1, paddingVertical: 0, }} keyboardType="email-adress"></TextInput>
        </View>

        <View style={{ flexDirection: 'row', borderBottomColor: '#ccc', borderBottomWidth: 1, paddingBottom: 8, marginBottom: 25, }}>
          <TextInput placeholder="Senha" style={{ flex: 1, paddingVertical: 0, }} secureTextEntry={true}></TextInput>
        </View>

        <View style={{ flexDirection: 'row', borderBottomColor: '#ccc', borderBottomWidth: 1, paddingBottom: 8, marginBottom: 25, }}>
          <TextInput placeholder="Confirme a Senha" style={{ flex: 1, paddingVertical: 0, }} secureTextEntry={true}></TextInput>
        </View>

        <View style={{ flexDirection: 'row', borderBottomColor: '#ccc', borderBottomWidth: 1, paddingBottom: 8, marginBottom: 25, }}>
          <TextInput placeholder="Nome completo" style={{ flex: 1, paddingVertical: 0, }} keyboardType="email-adress"></TextInput>
        </View>

        <View style={{ flexDirection: 'row', borderBottomColor: '#ccc', borderBottomWidth: 1, paddingBottom: 8, marginBottom: 25, }}>
          <TextInput placeholder="Data de Nascimento" style={{ flex: 1, paddingVertical: 0, }} keyboardType="numeric"></TextInput>
        </View>

        <TouchableOpacity style={{ backgroundColor: '#AD40AF', padding: 20, borderRadius: 10, marginBottom: 30, }}><Text style={{ textAlign: 'center', fontWeight: '700', fontSize: 16, color: '#fff', }}>Criar conta</Text></TouchableOpacity>

        <View style={{ flexDirection: 'row', justifyContent: 'center', marginBottom: 30, }}>
          <Text>Já possui Conta?</Text>
          <TouchableOpacity><Text style={{ color: '#AD40AF', fontWeight: '700', }}> Faça Login</Text></TouchableOpacity>
        </View>

      </View>
    </SafeAreaView>

  )
}

