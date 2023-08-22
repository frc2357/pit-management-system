import { Button } from '@react-native-material/core';
import RNBluetoothClassic, {BluetoothDevice}from 'react-native-bluetooth-classic'
export default (address) =>{
  <view><Button onPress={() => {for(i =2; i>0;i--){
    try {
      if(RNBluetoothClassic!=null){
      RNBluetoothClassic.pairDevice(address);
      RNBluetoothClassic.writeToDevice(address,"i really hope that this works\n","binary");
      console.log("it worked");
      break;}else{console.log("thing was null, so nothing happened");}
    } catch (error) {
      console.log(error);
    }
    }}}><label>do the bluetooth thing</label></Button></view>
    
  }