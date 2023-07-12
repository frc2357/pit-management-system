import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import Header from './components/headers/Header';

function App() {
  return (
    <View style={styles.container}>
      <StatusBar hidden={true}/>
      <Header/>
    </View>
  ); 
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
  },
 });


export default App;