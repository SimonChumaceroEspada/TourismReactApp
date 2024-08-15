import React from "react";
import { ScrollView, View, Text, Image, StyleSheet } from "react-native";
import useTouristicPlaces from "../hooks/useTouristicPlaces";

const TouristicPlacesList = () => {
  const touristicPlaces = useTouristicPlaces();

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <Text style={styles.title}>Lista de Lugares</Text>
      {touristicPlaces.map((touristicPlace) => (
        <View key={touristicPlace.id} style={styles.item}>
          <Text style={styles.name}>espName: {touristicPlace.espName}</Text>
          <Text style={styles.name}>engName: {touristicPlace.engName}</Text>
          <Text>engDescription: {touristicPlace.engDescription}</Text>
          <Text>espDescription: {touristicPlace.espDescription}</Text>
          <Image source={{ uri: touristicPlace.image }} style={styles.image} />
        </View>
      ))}
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 10,
  },
  title: {
    fontSize: 24,
    fontWeight: "bold",
    marginBottom: 10,
  },
  item: {
    marginBottom: 20,
  },
  name: {
    fontSize: 18,
    fontWeight: "bold",
  },
  image: {
    width: 200,
    height: 200,
  },
});

export default TouristicPlacesList;