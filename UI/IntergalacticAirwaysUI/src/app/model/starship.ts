export class Starship {

    // {
    //     "name": "Trade Federation cruiser",
    //     "model": "Providence-class carrier/destroyer",
    //     "manufacturer": "Rendili StarDrive, Free Dac Volunteers Engineering corps.",
    //     "passengers": "48247",
    //     "pilots": [
    //       "https://swapi.dev/api/people/10/",
    //       "https://swapi.dev/api/people/11/"
    //     ]
    //   },
    name: string | undefined;
    model: string | undefined;
    manufacturer: string| undefined;
    passengers: string| undefined;
    pilots: string[] | undefined;
}
