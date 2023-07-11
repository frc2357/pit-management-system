import React from 'react';
import { View, StyleSheet, Text } from 'react-native';

const DefaultHeader = () => {
  return (
    <View style={styles.headerBox}>
      <Text style={styles.text}>P.M.S</Text>
      <View style={styles.orangeTriangle}></View>
    </View>
  );
};

const styles = StyleSheet.create({
  headerBox: {
    flex: '0%',
    alignItems: 'center',
    justifyContent: 'center',
    width: '100%',
    height: '10%',
    backgroundColor: '#192734',
  },
  text: {
    color: '#FFFFFF',
    left: '-20%',
  },
  orangeTriangle: {
    width: 0,
    height: 0,
    backgroundColor: 'transparent',
    borderStyle: 'solid',
    borderTopWidth: 0,
    borderRightWidth: 90,
    borderBottomWidth: 90,
    borderLeftWidth: 0,
    borderTopColor: 'transparent',
    borderRightColor: 'transparent',
    borderBottomColor: '#FF7800',
    borderLeftColor: 'transparent',
  },
  greenTriangle: {},
});

export default DefaultHeader;