// Fill out your copyright notice in the Description page of Project Settings.

#include "Objcon.h"

#include <sstream>
#include <algorithm>
#include <iterator>
#include <vector>
#include <string>
#include <map>
#include <iostream>

std::vector<std::string> split(const std::string& str, const std::string& delimiters = " ", bool trimEmpty = true)
{
	std::vector<std::string> result;
	std::string::size_type pos, lastPos = 0, length = str.length();

	while (lastPos < length + 1)
	{
		pos = str.find_first_of(delimiters, lastPos);
		if (pos == std::string::npos)
		{
			pos = length;
		}

		if (pos != lastPos || !trimEmpty)
			result.push_back(std::string(str.data() + lastPos, pos - lastPos));

		lastPos = pos + 1;
	}

	return result;
}

// Sets default values
AObjcon::AObjcon()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

FMeshData AObjcon::load(FString source)
{
	TArray<FVector> positions;
	TArray<FVector2D> textureCoords;
	TArray<FVector> normals;
	TArray<int32> indices;

	bool hasPositions = false;
	bool hasTextureCoords = false;
	bool hasNormals = false;

	{
		std::vector<FVector> tempPositions;
		std::vector<FVector2D> tempTextureCoords;
		std::vector<FVector> tempNormals;
		std::map<std::string, int32> verticesToIndices;

		int lineBeginning = 0;
		for (size_t lineEnding = 0; lineEnding < source.Len(); ++lineEnding) {
			if (source[lineEnding] != '\n' && lineEnding + 1 != source.Len()) {
				continue;
			}

			std::string line;
			line.resize(lineEnding - lineBeginning);
			memcpy(&line[0], &source[0] + lineBeginning, line.size());
			lineBeginning = static_cast<int>(lineEnding) + 1;

			std::vector<std::string> tokens = split(line, " ");
			if (tokens.size() > 1) {
				if (tokens[0] == "v" && tokens.size() == 4) {
					// Parse position
					FVector position;
					position.X = std::stof(tokens[1]);
					position.Y = std::stof(tokens[2]);
					position.Z = std::stof(tokens[3]);

					tempPositions.push_back(position);
				}
				else if (tokens[0] == "vt" && tokens.size() == 3) {
					// Parse texture coords
					FVector2D textureCoord;
					textureCoord.X = std::stof(tokens[1]);
					textureCoord.Y = 1.0f - std::stof(tokens[2]);

					tempTextureCoords.push_back(textureCoord);
				}
				else if (tokens[0] == "vn" && tokens.size() == 4) {
					// Parse normal
					FVector normal;
					normal.X = std::stof(tokens[1]);
					normal.Y = std::stof(tokens[2]);
					normal.Z = std::stof(tokens[3]);

					tempNormals.push_back(normal);
				}
				else if (tokens[0] == "f" && tokens.size() == 4) {
					// Parse face
					for (size_t i = 0; i < 3; ++i) {
						const std::string& token = tokens[i + 1];
						auto it = verticesToIndices.find(token);
						if (it == verticesToIndices.end()) {
							std::vector<std::string> subtokens = split(token, "/");

							std::cout << subtokens.size() << "\n";

							if (subtokens.size() > 0) {
								positions.Add(tempPositions.at(std::stoull(subtokens[0]) - 1));
							}
							if (subtokens.size() > 1) {
								textureCoords.Add(tempTextureCoords.at(std::stoull(subtokens[1]) - 1));
							}
							if (subtokens.size() > 2) {
								normals.Add(tempNormals.at(std::stoull(subtokens[2]) - 1));
							}

							unsigned int index = static_cast<unsigned int>(tempPositions.size());
							verticesToIndices[token] = index;
							indices.Add(index);
						}
						else {
							indices.Add(it->second);
						}
					}
				}
			}
		}
	}

	FMeshData result;
	result.positions = positions;
	result.textureCoords = textureCoords;
	result.normals = normals;
	return result;
}

// Called when the game starts or when spawned
void AObjcon::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AObjcon::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

