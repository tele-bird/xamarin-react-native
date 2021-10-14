/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component, useState } from 'react';
import {
  Platform,
  StyleSheet,
  Text,
  TextInput,
  View,
  Button,
  Alert
} from 'react-native';

const messageFromInstructions = Platform.select({
  ios: 'Message from Xamarin.iOS',
  android: 'Message from Xamarin.Droid',
});

const messageToInstructions = Platform.select({
  ios: 'Message to Xamarin.iOS',
  android: 'Message to Xamarin.Droid',
});

const messageFromXamarin = "sample from";
const messageToXamarin = "sample to";

type Props = {};
export default class App extends Component<Props> {
  render() {
    return (
      <View style={styles.container}>
        <Text style={styles.instructions}>
          {messageFromInstructions}
        </Text>
        <TextInput value={messageFromXamarin} />
        <Text style={styles.instructions}>
          {messageToInstructions}
        </Text>
        <TextInput value={messageToXamarin} />
        <Button title="Press me" onPress={() => Alert.alert("Text was: " + {messageToXamarin})} />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
  },
  welcome: {
    fontSize: 20,
    textAlign: 'center',
    margin: 10,
  },
  instructions: {
    textAlign: 'center',
    color: '#333333',
    marginBottom: 5,
  },
});