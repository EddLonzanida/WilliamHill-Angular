export class SearchResponseBase<T> {
    constructor(
        public recordCount = 0,
        public rowsPerPage = 0,
        public items: T[] = []
    ) { }
}
