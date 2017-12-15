var RaceStat = /** @class */ (function () {
    function RaceStat(id, name, status, raceTotalAmount, horseStats, start) {
        if (id === void 0) { id = 0; }
        if (name === void 0) { name = ''; }
        if (status === void 0) { status = ''; }
        if (raceTotalAmount === void 0) { raceTotalAmount = 0; }
        if (horseStats === void 0) { horseStats = []; }
        this.id = id;
        this.name = name;
        this.status = status;
        this.raceTotalAmount = raceTotalAmount;
        this.horseStats = horseStats;
        this.start = start;
    }
    return RaceStat;
}());
export { RaceStat };
