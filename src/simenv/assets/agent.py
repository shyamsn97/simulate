from .asset import Asset


class Agent(Asset):
    dimensionality = 3

    def __init__(self, name, translation=[0, 0, 0], rotation=[0, 0, 0, 1], scale=[1, 1, 1]):
        super().__init__(name, translation, rotation, scale)