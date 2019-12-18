export class SearchRequestBase {
    constructor(
        public search = '',
        public page = 0,
        public sortColumn = 0,
        public isDescending = 0) {
    }
}
