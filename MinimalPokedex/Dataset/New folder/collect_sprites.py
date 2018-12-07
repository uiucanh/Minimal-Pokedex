import requests
import json

url = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/"
NUM_POKEMONS = 801
for i in range(1, NUM_POKEMONS + 1):
	img_data = requests.get(url + str(i) + ".png").content
	with open(str(i) + '.png', 'wb') as handler:
	    handler.write(img_data)
