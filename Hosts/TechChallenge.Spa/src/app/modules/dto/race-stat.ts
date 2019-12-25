import { HorseStat } from './horse-stat';

export class RaceStat {
    constructor(public id = 0,
                public name = '',
                public status = '',
                public raceTotalAmount = 0,
                public horseStats: HorseStat[] = [],
                public start: Date) { }
}
