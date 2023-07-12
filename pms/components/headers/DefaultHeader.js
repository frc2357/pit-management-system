import React from 'react';
import { View, StyleSheet, Text } from 'react-native';

const DefaultHeader = () => {
  return (
    <View style={styles.headerBox}>
      <Text  style={styles.text}>P.M.S</Text>
      <View style={styles.orangeTriangle}></View>
    </View>
  );
};

const styles = StyleSheet.create({
  headerBox: {
    flex: 0,
    alignItems: 'center',
    width: '100%',
    height: '10%',
    backgroundColor: '#192734',
  },
  text: {
    color: '#FFFFFF',
    left: '-20%',
    textAlign: 'center'
  },
  orangeTriangle: {
    width: 0,
    height: '100%',
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderTopWidth: 0,
    borderRightWidth: 0,
    borderBottomWidth: 180,
    borderLeftWidth: 90,
    borderTopColor: 'transparent',
    borderRightColor: 'transparent',
    borderBottomColor: '#FF7800',
    borderLeftColor: 'transparent',
    transform: [{rotate: '-90deg'}]
  },
  greenTriangle: {},
});

export default DefaultHeader;