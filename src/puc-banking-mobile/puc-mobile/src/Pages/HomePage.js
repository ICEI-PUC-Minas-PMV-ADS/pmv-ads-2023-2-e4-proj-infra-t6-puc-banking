import React, { useContext } from "react";
import { View, Text, StyleSheet, Image } from "react-native";
import { Button } from 'native-base';
import UserContext from '../contexts/UserContext';

const cardBrand = require('../../assets/puc-logo-light.png');

export default function HomePage() {

  const { userData, cardData } = useContext(UserContext);

  return (
    <View style={{ height: "100%" }}>
      <View style={styles.container}>
        <View style={styles.card}>
          <Image style={styles.cardBrand} source={cardBrand}></Image>
          <View style={styles.cardSection}>
            <View>
              <Text style={styles.cardNumber}>{cardData.number}</Text>
              <Text style={styles.cardHolder}>{cardData.name}</Text>
            </View>
            <View style={styles.cardSection}>
              <View>
                <Text style={styles.cardLabel}>CVV</Text>
                <Text style={styles.cardValue}>{cardData.CVV}</Text>
              </View>
              <View style={{marginLeft: 12}}>
                <Text style={styles.cardLabel}>Validate</Text>
                <Text style={styles.cardValue}>{cardData.validate}</Text>
              </View>
            </View>
          </View>
        </View>

        <View style={styles.billContainer}>
          <Text style={styles.billLabel}>Fatura atual</Text>
          <Text style={styles.billValue}>R${cardData.creditLimit - cardData.availableCreditLimit}</Text>
          <Button style={styles.payButton}>Pagar</Button>
        </View>

        <View style={styles.row}>
          <View style={styles.limitContainer}>
            <Text style={styles.limitLabel}>Limite utilizado</Text>
            <Text style={styles.limitValue}>R${cardData.creditLimit - cardData.availableCreditLimit}</Text>
          </View>
          <View style={styles.freeLimitContainer}>
            <Text style={styles.freeLimitLabel}>Limite disponível</Text>
            <Text style={styles.freeLimitValue}>{`R$ ${cardData.availableCreditLimit}`}</Text>
          </View>
        </View>
      </View>
    </View>
  );
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'column',
    alignItems: 'center',
    paddingTop: 12
  },
  card: {
    width: '90%',
    backgroundColor: '#7076F4',
    height: 200,
    borderRadius: 12,
    flex: 0,
    flexDirection: 'column',
    justifyContent: 'space-between',
    padding: 20
  },
  cardBrand: {
    width: 80,
    height: 60
  },
  cardSection: {
    flex: 0,
    flexDirection: 'row',
    justifyContent: 'space-between'
  },
  cardNumber: {
    color: 'white'
  },
  cardHolder: {
    color: 'white'
  },
  cardLabel: {
    color: '#e1e1e1',
    fontWeight: '600'
  },
  cardValue: {
    color: 'white'
  }, 
  billContainer: {
    width: '90%',
    marginTop: 20,
    backgroundColor: '#F5F4F4',
    borderRadius: 12,
    padding: 12,
    flex: 0,
    flexDirection: 'column',
    alignItems: "center"
  },
  billLabel: {
    fontWeight: 'bold',
    alignSelf: 'flex-start',
    marginBottom: 12
  },
  billValue: {
    fontSize: 20,
    fontWeight: 'bold',
    marginVertical: 20
  },
  payButton: {
    alignSelf: 'flex-start',
    backgroundColor: '#969BF7',
    width: 100
  },
  row: {
    width: '90%',
    flex: 0,
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginTop: 20
  },
  limitContainer: {
    width: '48%',
    backgroundColor: '#F5F4F4',
    borderRadius: 12,
    padding: 12,
    flex: 0,
    flexDirection: 'column',
    alignItems: "center"
  },
  limitLabel: {
    fontWeight: 'bold',
    alignSelf: 'flex-start',
  },
  limitValue: {
    fontSize: 16,
    fontWeight: 'bold',
    marginVertical: 12
  },
  freeLimitContainer: {
    width: '48%',
    backgroundColor: '#F5F4F4',
    borderRadius: 12,
    padding: 12,
    flex: 0,
    flexDirection: 'column',
    alignItems: "center"
  },
  freeLimitLabel: {
    fontWeight: 'bold',
    alignSelf: 'flex-start',
  },
  freeLimitValue: {
    fontSize: 16,
    fontWeight: 'bold',
    marginVertical: 12
  },
});
