namespace BDSA2016.Lecture07.Lib.Facade
{
    public class Facade
    {
        private readonly Notifier _notifier = new Notifier();
        private readonly Publisher _publisher = new Publisher();
        private readonly Archiver _archiver = new Archiver();
        private readonly PeopleRepository _peopleRepository = new PeopleRepository();

        public void Publish(Article article)
        {
            _publisher.PublishOnline(article);
            _archiver.Archive(article);

            var people = _peopleRepository.All();

            _notifier.Notify(article, people);
        }
    }
}
