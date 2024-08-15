import React from "react";
import { ScrollView, View, Text, Image, StyleSheet } from "react-native";
import usePlaces from "../hooks/usePlaces";

const PlacesList = () => {
  const places = usePlaces();

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <Text style={styles.title}>Lista de Lugares</Text>
      {places.map((place) => (
        <View key={place.id} style={styles.item}>
          <Text style={styles.name}>{place.name}</Text>
          <Text>{place.espDescription}</Text>
          <Text>{place.engDescription}</Text>
          <Text>
            <strong>Capital:</strong> {place.capital}
          </Text>
          <Image source={{ uri: place.image }} style={styles.image} />
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

export default PlacesList;