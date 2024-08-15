import { StatusBar } from "expo-status-bar";
import { StyleSheet, ScrollView, View } from "react-native";
import PlacesList from "./assets/components/PlacesList";
import TouristicPlacesList from "./assets/components/TouristicPlacesList";

export default function App() {
  return (
    <ScrollView contentContainerStyle={styles.container}>
      <PlacesList />
      <TouristicPlacesList />
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: {
    padding: 10,
    backgroundColor: "#fff",
  },
});