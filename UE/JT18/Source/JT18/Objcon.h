// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Objcon.generated.h"

USTRUCT(BlueprintType)
struct FMeshData
{
	GENERATED_BODY()

public:
	UPROPERTY(EditAnywhere, BlueprintReadWrite)
		TArray<FVector> positions;

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
		TArray<FVector2D> textureCoords;

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
		TArray<FVector> normals;

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
		TArray<int32> indices;
};

UCLASS()
class JT18_API AObjcon : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AObjcon();

	

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	UFUNCTION(BlueprintCallable)
		FMeshData load(FString soure);
	
};
