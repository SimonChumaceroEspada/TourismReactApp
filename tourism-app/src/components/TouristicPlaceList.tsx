import React from "react";
import useTouristicPlaces from "../hooks/useTouristicPlaces";

const TouristicPlacesList = () => {
  const touristicPlaces = useTouristicPlaces();

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4">Lista de Lugares</h1>
      {touristicPlaces.map((touristicPlace) => (
        <div key={touristicPlace.id} className="mb-6">
          <h2 className="text-lg font-semibold">espName: {touristicPlace.espName}</h2>
          <h2 className="text-lg font-semibold">engName: {touristicPlace.engName}</h2>
          <p>engDescription: {touristicPlace.engDescription}</p>
          <p>espDescription: {touristicPlace.espDescription}</p>
          <img src={touristicPlace.image} alt={touristicPlace.engName} className="w-48 h-48 object-cover" />
        </div>
      ))}
    </div>
  );
};

export default TouristicPlacesList;
