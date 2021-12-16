

import torch
import torch.nn as nn
import torch.optim as optim
import time
from torch.utils.data import Dataset, DataLoader
from torchvision import datasets, models, transforms
# load and show an image with Pillow
from PIL import Image
# load the image
image = Image.open('images.jpg')
# summarize some details about the image
print(image.format)
print(image.mode)
print(image.size)
# show the image
image.show()
# load and display an image with Matplotlib
from matplotlib import image
from matplotlib import pyplot
# load image as pixel array
data = image.imread('images.jpg')
# summarize shape of the pixel array
print(data.dtype)
print(data.shape)
# display the array of pixels as an image
pyplot.imshow(data)
pyplot.show()

# create a thumbnail of an image
from PIL import Image
# load the image
image = Image.open('images.jpg')
# report the size of the image
print(image.size)
# create a thumbnail and preserve aspect ratio
image.thumbnail((100,100))
# report the size of the thumbnail
print(image.size)


device = torch.device('cuda:0' if torch.cuda.is_available() else
'cpu')
class ImageClassifierDataset(Dataset):
    def __init__(self, image_list, image_classes):
        self.images = []
        self.labels = []
        self.classes = list(set(image_classes))
        self.class_to_label = {c: i for i, c in enumerate(self.classes)}
        self.image_size = 224
        self.transforms = transforms.Compose([
        transforms.Resize(self.image_size),
        transforms.CenterCrop(self.image_size),
        transforms.ToTensor(),
        transforms.Normalize((0.5,0.5,0.5), (0.5,0.5,0.5))
        ])
        for image, image_class in zip(image_list, image_classes):
            transformed_image = self.transforms(image)
        self.images.append(transformed_image)
        label = self.class_to_label[image_class]
        self.labels.append(label)
    def __getitem__(self, index):
        return self.images[index], self.labels[index]
    def __len__(self):
        return len(self.images)