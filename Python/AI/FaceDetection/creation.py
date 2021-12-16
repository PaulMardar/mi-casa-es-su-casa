import requests

for i in range(0, 50):
    response = requests.get("https://fakeface.rest/face/json?gender=male")
    response = response.json()
    print(response["image_url"])
    response = requests.get(response["image_url"])

    file = open("GUYS" + str(i + 1) + ".png", "wb")
    file.write(response.content)
    file.close()

for i in range(0, 50):
    response = requests.get("https://fakeface.rest/face/json?gender=female")
    response = response.json()
    print(response["image_url"])
    response = requests.get(response["image_url"])

    file = open("Gals" + str(i + 1) + ".png", "wb")
    file.write(response.content)
    file.close()
