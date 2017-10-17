import { RaceStat } from '../dto/race-stat';

export class RaceStatResponse {
    constructor(public raceStats: RaceStat[] = []) { }
}
