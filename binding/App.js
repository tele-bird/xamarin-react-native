/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

 import React, { Component, useState } from "react";
 import {
   Platform,
   StyleSheet,
   Text,
   TextInput,
   View,
   Button,
   Alert,
 } from "react-native";

import XamarinModule from './XamarinModule';

 const viewTitle = Platform.select({
   ios: "React.iOS",
   android: "React.Droid",
 })
 
 const messageFromInstructions = Platform.select({
   ios: "Message from Xamarin.iOS",
   android: "Message from Xamarin.Droid",
 });
 
 const messageToInstructions = Platform.select({
   ios: "Message to Xamarin.iOS",
   android: "Message to Xamarin.Droid",
 });
 
 export default class App extends Component {
   constructor(props) {
     super(props);
     this.state = { receiveText: "", sendText: "hello Xamarin", delay: "2000" };
   }
 
   render() {
     return (
       <View style={styles.container}>
         <View style={styles.titleContainer}>
         <Text style={styles.title}>{viewTitle}</Text>
         </View>
         <Text style={styles.instructions}>{messageFromInstructions}</Text>
         <TextInput
           style={styles.inputoneline}
           value={this.state.text}
           multiline
           onChangeText={(receiveText) => this.setState({ receiveText })}
           underlineColorAndroid="transparent"
         />
         <Text style={styles.instructions}>{messageToInstructions}</Text>
         <TextInput
           style={styles.inputoneline}
           onChangeText={(sendText) => this.setState({ sendText })}
           value={this.state.sendText}
           multiline
           underlineColorAndroid="transparent"
         />
         <Button
           title="Invoke Synchronous Without Response"
           onPress={() => XamarinModule.InvokeMeSynchronous(this.state.sendText)}
         />
         <Button
           title="Invoke Asynchronous With Delayed Callback"
           onPress={() => XamarinModule.InvokeMeAsynchronousWithCallback(this.state.delay, this.state.sendText, (error) => Alert.alert("error", error), (success) => Alert.alert("success", success))}
         />
         <Button
           title="Invoke Asynchronous With Delayed Promise"
           onPress={() => InvokeAsyncWithPromise(this.state.delay, this.state.sendText)}
         />
         <Text
           style={styles.instructions}>Delay:</Text>
         <TextInput
           style={styles.inputoneline}
           onChangeText={(delay) => this.setState({ delay })}
           value={this.state.delay}
           underlineColorAndroid="transparent"
         />
       </View>
     );
   }
 }

  async function InvokeAsyncWithPromise(delay, text) {
    try {
      var messageFromXamarin = await XamarinModule.InvokeMeAsynchronousWithPromise(delay, text);
      Alert.alert("success", messageFromXamarin);
    } catch (e) {
      // for some reason, the next line of code throws an exception: com.facebook.react.bridge.ReadableNativeMap cannot be cast to java.lang.String
      //Alert.alert("error", e);
    }
  }
 
 const styles = StyleSheet.create({
   container: {
     flex: 1,
     justifyContent: "center",
     alignItems: "center",
     backgroundColor: "#F5FCFF",
   },
   titleContainer: {
     flex: 1,
     alignItems: "center",
   },
   title: {
     fontSize: 20,
     textAlign: "center",
     textAlignVertical: "top",
     margin: 10,
   },
   instructions: {
     textAlign: "left",
     color: "#333333",
     marginBottom: 5,
   },
   input: {
     height: 150,
     width: 300,
     margin: 12,
     borderWidth: 1,
     padding: 10,
     textAlign: "left",
     textAlignVertical: "top"
   },
   inputoneline: {
     margin: 12,
     width: 300,
     borderWidth: 1,
     padding: 10,
     textAlign: "left",
   }
 });
 